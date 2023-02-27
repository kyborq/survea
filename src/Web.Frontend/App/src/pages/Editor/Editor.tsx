import React from "react";
import { useForm } from "react-hook-form";
import { Button } from "../../components/button/Button";
import { Input } from "../../components/input/Input";

import { Wrap } from "../../components/wrap/Wrap";
import {
  Configuration,
  CreateTestDto,
  Question,
  TestApi,
} from "../../services";
import { EditorForm, TQuestionForm } from "./components/EditorForm";

export const Editor = () => {
  const { control, register, getValues } = useForm<TQuestionForm>({
    defaultValues: {
      name: "Опросник",
      questions: [
        {
          questionName: "Вы собака?",
          choices: ["Да", "Нет", "Я кот"],
          questionType: 0,
        },
      ],
    },
  });

  return (
    <Wrap title="Редактор" icon="edit">
      <Input icon="info" placeholder="Название опроса" {...register("name")} />
      <EditorForm control={control} register={register} />
      <Button
        label="Сохранить"
        onClick={async () => {
          const { name, questions } = getValues();

          const test: CreateTestDto = {
            ageRestriction: 0,
            description: "",
            tags: [],
            name,
            questions,
          };

          // console.log(test);

          const config = new Configuration({
            basePath: "http://localhost:5001",
          });

          const testApi = new TestApi(config);

          const result = await testApi.apiTestPost(test, {
            withCredentials: true,
          });

          // console.log(result);
        }}
      />
    </Wrap>
  );
};
