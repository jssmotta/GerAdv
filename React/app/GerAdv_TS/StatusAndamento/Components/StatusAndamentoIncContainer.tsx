'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import StatusAndamentoInc from '../Crud/Inc/StatusAndamento';
import { getParamFromUrl } from '@/app/tools/helpers';
interface StatusAndamentoIncContainerProps {
  id: number;
  navigator: INavigator;
}
const StatusAndamentoIncContainer: React.FC<StatusAndamentoIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <StatusAndamentoInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default StatusAndamentoIncContainer;