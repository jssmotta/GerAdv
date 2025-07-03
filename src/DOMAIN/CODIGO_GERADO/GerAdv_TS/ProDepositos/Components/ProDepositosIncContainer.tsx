'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProDepositosInc from '../Crud/Inc/ProDepositos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProDepositosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProDepositosIncContainer: React.FC<ProDepositosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProDepositosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProDepositosIncContainer;