'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProcessOutputRequestInc from '../Crud/Inc/ProcessOutputRequest';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProcessOutputRequestIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProcessOutputRequestIncContainer: React.FC<ProcessOutputRequestIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProcessOutputRequestInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProcessOutputRequestIncContainer;