import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button } from "../../components/button/Button";
import { Card } from "../../components/card/Card";
import { Wrap } from "../../components/wrap/Wrap";
import { Configuration, TestApi, TestDto } from "../../services";
import { useAppSelector } from "../../store/hooks";

import styles from "./TestQuestion.module.css";

export const Home = () => {
  const [tests, setTests] = useState<TestDto[]>([]);
  const navigate = useNavigate();

  const isLogged = useAppSelector((state) => state.user.logged);

  const getTests = async () => {
    const config = new Configuration({
      basePath: "http://localhost:5001",
    });

    const testApi = new TestApi(config);

    const result = await testApi.apiTestGet({
      withCredentials: true,
    });

    setTests(result.data);
  };

  useEffect(() => {
    getTests();
  }, []);

  return (
    <Wrap title="Главная" icon="home">
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          gap: 16,
        }}
      >
        {tests.map((test) => {
          return (
            <Card title={test.name}>
              <Button
                label="Пройти"
                primary
                onClick={() => {
                  // ...
                  navigate(`/test/${test.testId}`);
                }}
              />
            </Card>
          );
        })}
      </div>
    </Wrap>
  );
};
