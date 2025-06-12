'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProDepositosInc from '../Crud/Inc/ProDepositos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProDepositosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ProDepositosIncContainer: React.FC<ProDepositosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ProDepositosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ProDepositosIncContainer;