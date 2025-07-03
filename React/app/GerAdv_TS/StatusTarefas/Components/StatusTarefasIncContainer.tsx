'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import StatusTarefasInc from '../Crud/Inc/StatusTarefas';
import { getParamFromUrl } from '@/app/tools/helpers';
interface StatusTarefasIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const StatusTarefasIncContainer: React.FC<StatusTarefasIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <StatusTarefasInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default StatusTarefasIncContainer;