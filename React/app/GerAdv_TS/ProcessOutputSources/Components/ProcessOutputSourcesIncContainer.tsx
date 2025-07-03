'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProcessOutputSourcesInc from '../Crud/Inc/ProcessOutputSources';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProcessOutputSourcesIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProcessOutputSourcesIncContainer: React.FC<ProcessOutputSourcesIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProcessOutputSourcesInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProcessOutputSourcesIncContainer;