'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import StatusTarefasInc from '../Crud/Inc/StatusTarefas';
import { getParamFromUrl } from '@/app/tools/helpers';
interface StatusTarefasIncContainerProps {
  id: number;
  navigator: INavigator;
}
const StatusTarefasIncContainer: React.FC<StatusTarefasIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <StatusTarefasInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default StatusTarefasIncContainer;