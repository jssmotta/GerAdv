import React from 'react';
import { getParamId } from '../tools/defInc';

export const useIdParam = () => {
  const [id, setId] = React.useState<number | null>(null);

  React.useEffect(() => {
    setId(getParamId());
  }, []);

  return id;
};
