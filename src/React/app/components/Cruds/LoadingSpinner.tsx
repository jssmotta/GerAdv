import { Loader } from '@progress/kendo-react-indicators';

export const LoadingSpinner: React.FC = () => (
  <span>
    {' '}
    <Loader
      className="loadingSpinner"
      size="large"
      type={'converging-spinner'}
    />
  </span>
);
