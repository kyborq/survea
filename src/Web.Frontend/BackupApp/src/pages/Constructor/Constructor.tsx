import React, { useState } from "react";
import { useFieldArray, useForm } from "react-hook-form";
import { uuid4 } from "../../utils/uuid4";
import { Question } from "./components/Question";
import { Tools } from "./components/Tools";

type TQuestion = {
  questionType: number;
  choices: string[];
};

type TSurvey = {
  name: string;
  ageRestriction: number;
  description: string;
  tags: string[];
  questions: TQuestion[];
};

export const Constructor = () => {
  const [surveyForm, setSurveyForm] = useState<TSurvey>({
    name: "",
    ageRestriction: 0,
    description: "",
    tags: [],
    questions: [],
  });

  const { control } = useForm();
  const { fields, append, remove } = useFieldArray({ name: "survey", control });

  const addMultipleChoice = () => {
    append({ questionType: 1, choices: [] });
  };

  const addSingleChoice = () => {
    append({ questionType: 0, choices: [] });
  };

  const addTextChoice = () => {
    append({ questionType: 2, text: "" });
  };

  return (
    <>
      <h2>Конструктор опросов</h2>

      <Tools
        handleMultipleChoice={addMultipleChoice}
        handleOneChoice={addSingleChoice}
        handleTextChoice={addTextChoice}
      />

      {fields.map((item, i) => {
        console.log(item);
        const q = item;
        return <Question key={item.id} index={i} />;
      })}
    </>
  );
};
