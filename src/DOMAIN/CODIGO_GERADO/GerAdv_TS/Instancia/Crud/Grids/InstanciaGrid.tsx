//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { InstanciaEmpty } from '../../../Models/Instancia';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IInstancia } from '../../Interfaces/interface.Instancia';
import { InstanciaService } from '../../Services/Instancia.service';
import { InstanciaApi } from '../../Apis/ApiInstancia';
import { InstanciaGridMobileComponent } from '../GridsMobile/Instancia';
import { InstanciaGridDesktopComponent } from '../GridsDesktop/Instancia';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterInstancia } from '../../Filters/Instancia';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import InstanciaWindow from './InstanciaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useInstanciaList } from '../../Hooks/hookInstancia';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const InstanciaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const instanciaService = useMemo(() => {
    return new InstanciaService(
    new InstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: instancia, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useInstanciaList(instanciaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedInstancia, setSelectedInstancia] = useState<IInstancia>(InstanciaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterInstancia | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterInstancia | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterInstancia);
};
// Handlers para o grid
const handleRowClick = (instancia: IInstancia) => {
  setSelectedInstancia(instancia);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedInstancia(InstanciaEmpty());
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
  const instancia = e.dataItem;
  setDeleteId(instancia.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await instanciaService.deleteInstancia(deleteId);
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
    <InstanciaGridMobileComponent
    data={instancia}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <InstanciaGridDesktopComponent
    data={instancia}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <InstanciaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedInstancia={selectedInstancia}
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
export default InstanciaGrid;