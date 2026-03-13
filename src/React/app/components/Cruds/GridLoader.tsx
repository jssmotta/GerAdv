'use client';

import { Loader } from '@progress/kendo-react-indicators';
export const PMaxTimeToInit = 1000;
export const LoaderGrid = () => {
  return (
    <div className="loaderGrid">
      <Loader size="large" type={'converging-spinner'} />
    </div>
  );
};
