import React, { useEffect } from "react";
import { Control, Controller, UseFormRegister } from "react-hook-form";
import { Card } from "../../components/card/Card";
import { Input } from "../../components/input/Input";
import { TIcon } from "../../icons";
import { NewAttemptDto, Question } from "../../services";
import { SelectForm } from "./SelectForm";

import styles from "./TestQuestion.module.css";

type Props = {
  question: Question;
  index: number;
  control: Control<NewAttemptDto>;
  register: UseFormRegister<NewAttemptDto>;
};

export const TestQuestion: React.FC<Props> = ({
  question,
  control,
  index,
  register,
}) => {
  const qIcon: TIcon[] = ["circleCheck", "checkbox", "text"];

  useEffect(() => {
    register(`answers.${index}.questionType`, {
      value: question.questionType,
    });

    register(`answers.${index}.questionNumber`, {
      value: index,
    });
  }, [register]);

  return (
    <Card
      icon={qIcon[question.questionType]}
      title={question.questionName}
      className={styles.Card}
    >
      {question.questionType !== 2 ? (
        <Controller
          name={`answers.${index}.answerText`}
          rules={{
            required: true,
          }}
          control={control}
          render={({ field }) => {
            return (
              <SelectForm
                currentValue={field.value || ""}
                values={question.choices}
                onChange={field.onChange}
                multiple={question.questionType === 1}
              />
            );
          }}
        />
      ) : (
        <Input icon="text" {...register(`answers.${index}.answerText`)} />
      )}
    </Card>
  );
};
