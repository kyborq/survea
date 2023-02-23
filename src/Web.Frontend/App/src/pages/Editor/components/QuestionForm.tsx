import React from "react";

import { IconButton } from "../../../components/button/IconButton";
import { Card } from "../../../components/card/Card";
import { Input } from "../../../components/input/Input";

import styles from "./QuestionForm.module.css";

export const QuestionForm = () => {
  return (
    <Card>
      <Input
        icon="info"
        // label="Текст вопроса"
        placeholder="Введите текст вопроса"
      />
      <div className={styles.Options}>
        <Input
          icon="circleCheck"
          // label="Вариант №1"
          placeholder="Введите текст"
        />
        <Input
          icon="circleCheck"
          // label="Вариант №2"
          placeholder="Введите текст"
        />
        <Input
          icon="circleCheck"
          // label="Вариант №3"
          placeholder="Введите текст"
        />
        <Input
          icon="circleCheck"
          // label="Вариант №4"
          placeholder="Введите текст"
        />
      </div>
      {/* <div className={styles.Footer}>
        <IconButton icon="addCircle" />
        <IconButton icon="trash" />
      </div> */}
    </Card>
  );
};
