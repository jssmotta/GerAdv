//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { TipoOrigemSucumbenciaEmpty } from '../../../Models/TipoOrigemSucumbencia';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ITipoOrigemSucumbencia } from '../../Interfaces/interface.TipoOrigemSucumbencia';
import { TipoOrigemSucumbenciaService } from '../../Services/TipoOrigemSucumbencia.service';
import { TipoOrigemSucumbenciaApi } from '../../Apis/ApiTipoOrigemSucumbencia';
import { TipoOrigemSucumbenciaGridMobileComponent } from '../GridsMobile/TipoOrigemSucumbencia';
import { TipoOrigemSucumbenciaGridDesktopComponent } from '../GridsDesktop/TipoOrigemSucumbencia';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterTipoOrigemSucumbencia } from '../../Filters/TipoOrigemSucumbencia';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import TipoOrigemSucumbenciaWindow from './TipoOrigemSucumbenciaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useTipoOrigemSucumbenciaList } from '../../Hooks/hookTipoOrigemSucumbencia';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const TipoOrigemSucumbenciaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const tipoorigemsucumbenciaService = useMemo(() => {
    return new TipoOrigemSucumbenciaService(
    new TipoOrigemSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: tipoorigemsucumbencia, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useTipoOrigemSucumbenciaList(tipoorigemsucumbenciaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedTipoOrigemSucumbencia, setSelectedTipoOrigemSucumbencia] = useState<ITipoOrigemSucumbencia>(TipoOrigemSucumbenciaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterTipoOrigemSucumbencia | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterTipoOrigemSucumbencia | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterTipoOrigemSucumbencia);
};
// Handlers para o grid
const handleRowClick = (tipoorigemsucumbencia: ITipoOrigemSucumbencia) => {
  setSelectedTipoOrigemSucumbencia(tipoorigemsucumbencia);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedTipoOrigemSucumbencia(TipoOrigemSucumbenciaEmpty());
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
  const tipoorigemsucumbencia = e.dataItem;
  setDeleteId(tipoorigemsucumbencia.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await tipoorigemsucumbenciaService.deleteTipoOrigemSucumbencia(deleteId);
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
    <TipoOrigemSucumbenciaGridMobileComponent
    data={tipoorigemsucumbencia}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <TipoOrigemSucumbenciaGridDesktopComponent
    data={tipoorigemsucumbencia}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <TipoOrigemSucumbenciaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedTipoOrigemSucumbencia={selectedTipoOrigemSucumbencia}
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
export default TipoOrigemSucumbenciaGrid;