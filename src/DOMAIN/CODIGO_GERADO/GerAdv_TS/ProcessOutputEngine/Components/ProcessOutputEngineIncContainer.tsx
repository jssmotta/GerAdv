'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProcessOutputEngineInc from '../Crud/Inc/ProcessOutputEngine';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProcessOutputEngineIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProcessOutputEngineIncContainer: React.FC<ProcessOutputEngineIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProcessOutputEngineInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProcessOutputEngineIncContainer;