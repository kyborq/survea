type TClassName = string | boolean | null | undefined;

export const classNames = (...names: TClassName[]) => {
  return names.filter((name) => !!name).join(" ");
};
