import React from "react";
import { Control, UseFormRegister } from "react-hook-form";

import { Card } from "../../../components/card/Card";
import { Input } from "../../../components/input/Input";
import { TQuestionForm } from "./EditorForm";
import { OptionsForm } from "./OptionsForm";

type Props = {
  index: number;
  control: Control<TQuestionForm>;
  type: number;
  register: UseFormRegister<TQuestionForm>;
};

export const QuestionForm: React.FC<Props> = ({
  index,
  control,
  type,
  register,
}) => {
  return (
    <Card>
      <Input icon="info" {...register(`questions.${index}.questionName`)} />
      {type !== 2 && (
        <OptionsForm
          multi={type === 1}
          control={control}
          index={index}
          register={register}
        />
      )}
    </Card>
  );
};
