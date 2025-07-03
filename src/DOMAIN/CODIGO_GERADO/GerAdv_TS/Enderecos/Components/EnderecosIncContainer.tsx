'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import EnderecosInc from '../Crud/Inc/Enderecos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface EnderecosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const EnderecosIncContainer: React.FC<EnderecosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <EnderecosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default EnderecosIncContainer;