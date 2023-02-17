import React from "react";
import { icons, TIcon } from "../icons";

type Props = {
  name: TIcon;
  fill?: string;
  color?: string;
};

export const Icon: React.FC<Props> = ({ name, fill, color }) => {
  const IconComponent = icons[name];
  return <IconComponent fill={fill || "none"} stroke={color || "none"} />;
};
