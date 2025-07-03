'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProProcuradoresInc from '../Crud/Inc/ProProcuradores';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProProcuradoresIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProProcuradoresIncContainer: React.FC<ProProcuradoresIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProProcuradoresInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProProcuradoresIncContainer;