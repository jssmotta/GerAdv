//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AdvogadosEmpty } from '../../../Models/Advogados';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAdvogados } from '../../Interfaces/interface.Advogados';
import { AdvogadosService } from '../../Services/Advogados.service';
import { AdvogadosApi } from '../../Apis/ApiAdvogados';
import { AdvogadosGridMobileComponent } from '../GridsMobile/Advogados';
import { AdvogadosGridDesktopComponent } from '../GridsDesktop/Advogados';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAdvogados } from '../../Filters/Advogados';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AdvogadosWindow from './AdvogadosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAdvogadosList } from '../../Hooks/hookAdvogados';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const AdvogadosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const advogadosService = useMemo(() => {
    return new AdvogadosService(
    new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: advogados, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAdvogadosList(advogadosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAdvogados, setSelectedAdvogados] = useState<IAdvogados>(AdvogadosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAdvogados | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAdvogados | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAdvogados);
};
// Handlers para o grid
const handleRowClick = (advogados: IAdvogados) => {
  setSelectedAdvogados(advogados);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAdvogados(AdvogadosEmpty());
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
  const advogados = e.dataItem;
  setDeleteId(advogados.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await advogadosService.deleteAdvogados(deleteId);
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
    <AdvogadosGridMobileComponent
    data={advogados}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AdvogadosGridDesktopComponent
    data={advogados}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AdvogadosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAdvogados={selectedAdvogados}
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
export default AdvogadosGrid;