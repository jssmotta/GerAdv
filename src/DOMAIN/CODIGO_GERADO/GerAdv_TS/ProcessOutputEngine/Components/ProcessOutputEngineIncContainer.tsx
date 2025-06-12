'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProcessOutputEngineInc from '../Crud/Inc/ProcessOutputEngine';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProcessOutputEngineIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ProcessOutputEngineIncContainer: React.FC<ProcessOutputEngineIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ProcessOutputEngineInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ProcessOutputEngineIncContainer;