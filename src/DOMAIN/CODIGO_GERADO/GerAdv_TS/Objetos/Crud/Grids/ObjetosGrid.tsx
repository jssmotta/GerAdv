//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ObjetosEmpty } from '../../../Models/Objetos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IObjetos } from '../../Interfaces/interface.Objetos';
import { ObjetosService } from '../../Services/Objetos.service';
import { ObjetosApi } from '../../Apis/ApiObjetos';
import { ObjetosGridMobileComponent } from '../GridsMobile/Objetos';
import { ObjetosGridDesktopComponent } from '../GridsDesktop/Objetos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterObjetos } from '../../Filters/Objetos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ObjetosWindow from './ObjetosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useObjetosList } from '../../Hooks/hookObjetos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const ObjetosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const objetosService = useMemo(() => {
    return new ObjetosService(
    new ObjetosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: objetos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useObjetosList(objetosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedObjetos, setSelectedObjetos] = useState<IObjetos>(ObjetosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterObjetos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterObjetos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterObjetos);
};
// Handlers para o grid
const handleRowClick = (objetos: IObjetos) => {
  setSelectedObjetos(objetos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedObjetos(ObjetosEmpty());
  setShowInc(true);
};
const handleClose = () => {
  setShowInc(false);
};
const handleSuccess = () => {
  setShowInc(false);
  // O hook já escuta as notificações e recarrega automaticamente
};
const handleError = () => {
  setShowInc(false);
};
// Handlers para exclusão
const onDeleteClick = (e: any) => {
  const objetos = e.dataItem;
  setDeleteId(objetos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await objetosService.deleteObjetos(deleteId);
      // O hook já escuta as notificações e recarrega automaticamente
    } catch (error) {
    console.error('Erro ao excluir:', error);
    setErrorMessage('Erro ao excluir o registro. Verifique se ele não está vinculado a outros registros.');
  } finally {
  setDeleteId(null);
  setIsModalOpen(false);
}
}
};
const cancelDelete = () => {
  setDeleteId(null);
  setIsModalOpen(false);
};
// Combinar erro do hook com erro local
const displayError = error || errorMessage;
useEffect(() => {
  const unsubscribe = subscribeToNotifications('*', (entity) => {
    reloadFilter();
  });
  return () => {
    unsubscribe();
  };
}, []);
return (
<>
<AppGridToolbar onAdd={handleAdd} />
{loading && (
  <LoadingSpinner />
  )}
  {isMobile ? (
    <ObjetosGridMobileComponent
    data={objetos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ObjetosGridDesktopComponent
    data={objetos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ObjetosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedObjetos={selectedObjetos}
    />
    <ConfirmationModal
    isOpen={isModalOpen}
    onConfirm={confirmDelete}
    onCancel={cancelDelete}
    message={`Deseja realmente excluir o registro?`}
    />
    <ErrorMessage
    mensagem={displayError}
    setErrorMessage={setErrorMessage}
    />
  </>
);
};
export default ObjetosGrid;