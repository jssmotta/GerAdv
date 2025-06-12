'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoRecursoInc from '../Crud/Inc/TipoRecurso';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoRecursoIncContainerProps {
  id: number;
  navigator: INavigator;
}
const TipoRecursoIncContainer: React.FC<TipoRecursoIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <TipoRecursoInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default TipoRecursoIncContainer;