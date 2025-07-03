//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { HonorariosDadosContratoEmpty } from '../../../Models/HonorariosDadosContrato';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IHonorariosDadosContrato } from '../../Interfaces/interface.HonorariosDadosContrato';
import { HonorariosDadosContratoService } from '../../Services/HonorariosDadosContrato.service';
import { HonorariosDadosContratoApi } from '../../Apis/ApiHonorariosDadosContrato';
import { HonorariosDadosContratoGridMobileComponent } from '../GridsMobile/HonorariosDadosContrato';
import { HonorariosDadosContratoGridDesktopComponent } from '../GridsDesktop/HonorariosDadosContrato';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterHonorariosDadosContrato } from '../../Filters/HonorariosDadosContrato';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import HonorariosDadosContratoWindow from './HonorariosDadosContratoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useHonorariosDadosContratoList } from '../../Hooks/hookHonorariosDadosContrato';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const HonorariosDadosContratoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const honorariosdadoscontratoService = useMemo(() => {
    return new HonorariosDadosContratoService(
    new HonorariosDadosContratoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: honorariosdadoscontrato, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useHonorariosDadosContratoList(honorariosdadoscontratoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedHonorariosDadosContrato, setSelectedHonorariosDadosContrato] = useState<IHonorariosDadosContrato>(HonorariosDadosContratoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterHonorariosDadosContrato | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterHonorariosDadosContrato | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterHonorariosDadosContrato);
};
// Handlers para o grid
const handleRowClick = (honorariosdadoscontrato: IHonorariosDadosContrato) => {
  setSelectedHonorariosDadosContrato(honorariosdadoscontrato);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedHonorariosDadosContrato(HonorariosDadosContratoEmpty());
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
  const honorariosdadoscontrato = e.dataItem;
  setDeleteId(honorariosdadoscontrato.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await honorariosdadoscontratoService.deleteHonorariosDadosContrato(deleteId);
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
    <HonorariosDadosContratoGridMobileComponent
    data={honorariosdadoscontrato}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <HonorariosDadosContratoGridDesktopComponent
    data={honorariosdadoscontrato}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <HonorariosDadosContratoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedHonorariosDadosContrato={selectedHonorariosDadosContrato}
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
export default HonorariosDadosContratoGrid;