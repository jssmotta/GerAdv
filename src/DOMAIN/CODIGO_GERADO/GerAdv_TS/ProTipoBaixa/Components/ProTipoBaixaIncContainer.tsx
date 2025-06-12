'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProTipoBaixaInc from '../Crud/Inc/ProTipoBaixa';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProTipoBaixaIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ProTipoBaixaIncContainer: React.FC<ProTipoBaixaIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ProTipoBaixaInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ProTipoBaixaIncContainer;