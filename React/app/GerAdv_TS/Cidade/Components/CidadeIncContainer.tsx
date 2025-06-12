'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import CidadeInc from '../Crud/Inc/Cidade';
import { getParamFromUrl } from '@/app/tools/helpers';
interface CidadeIncContainerProps {
  id: number;
  navigator: INavigator;
}
const CidadeIncContainer: React.FC<CidadeIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <CidadeInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default CidadeIncContainer;