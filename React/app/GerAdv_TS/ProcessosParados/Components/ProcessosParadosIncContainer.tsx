'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProcessosParadosInc from '../Crud/Inc/ProcessosParados';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProcessosParadosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProcessosParadosIncContainer: React.FC<ProcessosParadosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProcessosParadosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProcessosParadosIncContainer;