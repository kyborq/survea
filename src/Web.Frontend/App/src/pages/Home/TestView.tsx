import React, { useEffect, useState } from "react";
import { useFieldArray, useForm } from "react-hook-form";
import { useNavigate, useParams } from "react-router-dom";
import { Button } from "../../components/button/Button";
import { Card } from "../../components/card/Card";
import { Wrap } from "../../components/wrap/Wrap";
import {
  Configuration,
  AnswerDto,
  TestApi,
  TestDto,
  NewAttemptDto,
} from "../../services";
import { useAppSelector } from "../../store/hooks";
import { TestQuestion } from "./TestQuestion";

export const TestView = () => {
  const [test, setTest] = useState<TestDto>();
  const navigate = useNavigate();
  const { id } = useParams();

  const { control, register, getValues } = useForm<NewAttemptDto>({
    defaultValues: {
      answers: [],
      testId: +id,
    },
  });

  const { fields } = useFieldArray({
    control,
    name: "answers",
  });

  const getTests = async () => {
    const config = new Configuration({
      basePath: "http://localhost:5001",
    });

    const testApi = new TestApi(config);

    const result = await testApi.apiTestIdFullGet(+id, {
      withCredentials: true,
    });

    setTest(result.data);
  };

  useEffect(() => {
    getTests();
  }, []);

  return (
    <Wrap title={test?.name || "Тест"} icon="edit">
      {/* ... */}
      {!!test &&
        test.questions.map((q) => {
          return <TestQuestion question={q} />;
        })}
    </Wrap>
  );
};
