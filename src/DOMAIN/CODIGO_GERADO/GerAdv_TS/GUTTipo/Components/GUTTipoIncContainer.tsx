'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GUTTipoInc from '../Crud/Inc/GUTTipo';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GUTTipoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const GUTTipoIncContainer: React.FC<GUTTipoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <GUTTipoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default GUTTipoIncContainer;