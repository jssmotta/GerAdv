'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoRecursoInc from '../Crud/Inc/TipoRecurso';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoRecursoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const TipoRecursoIncContainer: React.FC<TipoRecursoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <TipoRecursoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default TipoRecursoIncContainer;