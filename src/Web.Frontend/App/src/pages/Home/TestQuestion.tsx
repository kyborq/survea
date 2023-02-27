import React from "react";
import { Control, UseFormRegister } from "react-hook-form";
import { Button } from "../../components/button/Button";
import { Card } from "../../components/card/Card";
import { Input } from "../../components/input/Input";
import { TIcon } from "../../icons";
import { AnswerDto, Question } from "../../services";

import styles from "./TestQuestion.module.css";

type Props = {
  question: Question;
  // control: Control<AnswerDto>;
  // register: UseFormRegister<AnswerDto>;
};

export const TestQuestion: React.FC<Props> = ({ question }) => {
  const qIcon: TIcon[] = ["circleCheck", "checkbox", "text"];

  return (
    <Card
      icon={qIcon[question.questionType]}
      title={question.questionName}
      className={styles.Card}
    >
      <div className={styles.Options}>
        {question.questionType !== 2 &&
          question.choices.map((c) => {
            if (question.questionType === 0 || question.questionType === 1) {
              return <Button label={c} icon={qIcon[question.questionType]} />;
            }
          })}
        {question.questionType === 2 && <Input icon="text" />}
      </div>
    </Card>
  );
};
