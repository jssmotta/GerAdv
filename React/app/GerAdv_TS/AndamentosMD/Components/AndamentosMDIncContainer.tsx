'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import AndamentosMDInc from '../Crud/Inc/AndamentosMD';
import { getParamFromUrl } from '@/app/tools/helpers';
interface AndamentosMDIncContainerProps {
  id: number;
  navigator: INavigator;
}
const AndamentosMDIncContainer: React.FC<AndamentosMDIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <AndamentosMDInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default AndamentosMDIncContainer;