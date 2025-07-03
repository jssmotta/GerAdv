'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ReuniaoPessoasInc from '../Crud/Inc/ReuniaoPessoas';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ReuniaoPessoasIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ReuniaoPessoasIncContainer: React.FC<ReuniaoPessoasIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ReuniaoPessoasInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ReuniaoPessoasIncContainer;