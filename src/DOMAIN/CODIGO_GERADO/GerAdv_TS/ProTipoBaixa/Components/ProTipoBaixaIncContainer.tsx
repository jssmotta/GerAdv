'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProTipoBaixaInc from '../Crud/Inc/ProTipoBaixa';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProTipoBaixaIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProTipoBaixaIncContainer: React.FC<ProTipoBaixaIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProTipoBaixaInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProTipoBaixaIncContainer;