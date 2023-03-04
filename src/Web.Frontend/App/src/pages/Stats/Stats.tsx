import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Card } from "../../components/card/Card";
import { Wrap } from "../../components/wrap/Wrap";
import {
  AttemptApi,
  AttemptDto,
  Configuration,
  TestApi,
  TestDto,
  UserApi,
} from "../../services";

export const Stats = () => {
  const [test, setTest] = useState<TestDto>();
  const [attempts, setAttempt] = useState<AttemptDto[]>();

  const { id } = useParams();

  const getTest = async (id: string) => {
    const config = new Configuration({
      basePath: "http://localhost:5001",
    });

    const attemptApi = new AttemptApi(config);
    const testApi = new TestApi(config);

    const result = await attemptApi.apiAttemptByTestIdIdGet(+id, {
      withCredentials: true,
    });
    const testRes = await testApi.apiTestIdGet(+id, {
      withCredentials: true,
    });

    setAttempt(result.data);
    setTest(testRes.data);
  };

  useEffect(() => {
    getTest(id);
  }, [id]);

  return (
    <Wrap title={test?.name || "Результаты"} icon="home">
      <div style={{ display: "flex", flexDirection: "column", gap: 16 }}>
        {test &&
          test?.questions.map((q, i) => {
            return (
              <Card title={q.questionName}>
                {attempts.map((a) => {
                  const answers: string[] = [];
                  const qAnswers = a.answers.filter(
                    (q) => q.questionNumber === i
                  );

                  qAnswers.forEach((qa) => {
                    if (!answers.includes(qa.answerText)) {
                      answers.push(qa.answerText);
                    }
                  });

                  return (
                    <div
                      style={{
                        padding: "16px 24px",
                        marginBottom: 8,
                        background: "#fafafa",
                        borderRadius: 14,
                      }}
                    >
                      {answers.map((q) => q)}
                    </div>
                  );
                })}
              </Card>
            );
          })}
      </div>
    </Wrap>
  );
};
