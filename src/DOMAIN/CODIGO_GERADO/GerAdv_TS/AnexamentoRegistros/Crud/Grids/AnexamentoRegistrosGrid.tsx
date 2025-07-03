//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AnexamentoRegistrosEmpty } from '../../../Models/AnexamentoRegistros';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAnexamentoRegistros } from '../../Interfaces/interface.AnexamentoRegistros';
import { AnexamentoRegistrosService } from '../../Services/AnexamentoRegistros.service';
import { AnexamentoRegistrosApi } from '../../Apis/ApiAnexamentoRegistros';
import { AnexamentoRegistrosGridMobileComponent } from '../GridsMobile/AnexamentoRegistros';
import { AnexamentoRegistrosGridDesktopComponent } from '../GridsDesktop/AnexamentoRegistros';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAnexamentoRegistros } from '../../Filters/AnexamentoRegistros';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AnexamentoRegistrosWindow from './AnexamentoRegistrosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAnexamentoRegistrosList } from '../../Hooks/hookAnexamentoRegistros';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const AnexamentoRegistrosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const anexamentoregistrosService = useMemo(() => {
    return new AnexamentoRegistrosService(
    new AnexamentoRegistrosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: anexamentoregistros, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAnexamentoRegistrosList(anexamentoregistrosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAnexamentoRegistros, setSelectedAnexamentoRegistros] = useState<IAnexamentoRegistros>(AnexamentoRegistrosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAnexamentoRegistros | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAnexamentoRegistros | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAnexamentoRegistros);
};
// Handlers para o grid
const handleRowClick = (anexamentoregistros: IAnexamentoRegistros) => {
  setSelectedAnexamentoRegistros(anexamentoregistros);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAnexamentoRegistros(AnexamentoRegistrosEmpty());
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
  const anexamentoregistros = e.dataItem;
  setDeleteId(anexamentoregistros.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await anexamentoregistrosService.deleteAnexamentoRegistros(deleteId);
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
    if (entity.action == NotifySystemActions.ERROR) {
      return;
    }
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
    <AnexamentoRegistrosGridMobileComponent
    data={anexamentoregistros}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AnexamentoRegistrosGridDesktopComponent
    data={anexamentoregistros}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AnexamentoRegistrosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAnexamentoRegistros={selectedAnexamentoRegistros}
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
export default AnexamentoRegistrosGrid;