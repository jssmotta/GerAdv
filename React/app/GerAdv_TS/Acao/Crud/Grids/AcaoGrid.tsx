//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AcaoEmpty } from '../../../Models/Acao';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAcao } from '../../Interfaces/interface.Acao';
import { AcaoService } from '../../Services/Acao.service';
import { AcaoApi } from '../../Apis/ApiAcao';
import { AcaoGridMobileComponent } from '../GridsMobile/Acao';
import { AcaoGridDesktopComponent } from '../GridsDesktop/Acao';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAcao } from '../../Filters/Acao';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AcaoWindow from './AcaoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAcaoList } from '../../Hooks/hookAcao';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const AcaoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const acaoService = useMemo(() => {
    return new AcaoService(
    new AcaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: acao, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAcaoList(acaoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAcao, setSelectedAcao] = useState<IAcao>(AcaoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAcao | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAcao | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAcao);
};
// Handlers para o grid
const handleRowClick = (acao: IAcao) => {
  setSelectedAcao(acao);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAcao(AcaoEmpty());
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
  const acao = e.dataItem;
  setDeleteId(acao.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await acaoService.deleteAcao(deleteId);
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
    <AcaoGridMobileComponent
    data={acao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AcaoGridDesktopComponent
    data={acao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AcaoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAcao={selectedAcao}
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
export default AcaoGrid;