import React from "react";

import { Wrap } from "../../components/wrap/Wrap";
import { QuestionPanel } from "./components/QuestionPanel";
import { QuestionForm } from "./components/QuestionForm";

export const Editor = () => {
  return (
    <Wrap title="Редактор" icon="edit">
      <QuestionPanel />
      <QuestionForm />
    </Wrap>
  );
};
