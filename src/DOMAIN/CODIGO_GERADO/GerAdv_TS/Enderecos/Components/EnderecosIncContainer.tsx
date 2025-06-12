'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import EnderecosInc from '../Crud/Inc/Enderecos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface EnderecosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const EnderecosIncContainer: React.FC<EnderecosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <EnderecosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default EnderecosIncContainer;