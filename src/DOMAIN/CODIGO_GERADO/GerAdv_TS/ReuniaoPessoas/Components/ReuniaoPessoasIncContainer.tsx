'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ReuniaoPessoasInc from '../Crud/Inc/ReuniaoPessoas';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ReuniaoPessoasIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ReuniaoPessoasIncContainer: React.FC<ReuniaoPessoasIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ReuniaoPessoasInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ReuniaoPessoasIncContainer;