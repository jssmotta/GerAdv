//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ServicosEmpty } from '../../../Models/Servicos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IServicos } from '../../Interfaces/interface.Servicos';
import { ServicosService } from '../../Services/Servicos.service';
import { ServicosApi } from '../../Apis/ApiServicos';
import { ServicosGridMobileComponent } from '../GridsMobile/Servicos';
import { ServicosGridDesktopComponent } from '../GridsDesktop/Servicos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterServicos } from '../../Filters/Servicos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ServicosWindow from './ServicosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useServicosList } from '../../Hooks/hookServicos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const ServicosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const servicosService = useMemo(() => {
    return new ServicosService(
    new ServicosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: servicos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useServicosList(servicosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedServicos, setSelectedServicos] = useState<IServicos>(ServicosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterServicos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterServicos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterServicos);
};
// Handlers para o grid
const handleRowClick = (servicos: IServicos) => {
  setSelectedServicos(servicos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedServicos(ServicosEmpty());
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
  const servicos = e.dataItem;
  setDeleteId(servicos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await servicosService.deleteServicos(deleteId);
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
    <ServicosGridMobileComponent
    data={servicos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ServicosGridDesktopComponent
    data={servicos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ServicosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedServicos={selectedServicos}
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
export default ServicosGrid;