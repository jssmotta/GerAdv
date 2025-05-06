//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ViaRecebimentoEmpty } from "../../../Models/ViaRecebimento";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IViaRecebimento } from "../../Interfaces/interface.ViaRecebimento";
import { ViaRecebimentoService } from "../../Services/ViaRecebimento.service";
import { ViaRecebimentoApi } from "../../Apis/ApiViaRecebimento";
import { ViaRecebimentoGridMobileComponent } from "../GridsMobile/ViaRecebimento";
import { ViaRecebimentoGridDesktopComponent } from "../GridsDesktop/ViaRecebimento";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterViaRecebimento } from "../../Filters/ViaRecebimento";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ViaRecebimentoWindow from "./ViaRecebimentoWindow";

const ViaRecebimentoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [viarecebimento, setViaRecebimento] = useState<IViaRecebimento[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedViaRecebimento, setSelectedViaRecebimento] = useState<IViaRecebimento>(ViaRecebimentoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ViaRecebimentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterViaRecebimento | undefined | null>(null);

    const viarecebimentoService = useMemo(() => {
      return new ViaRecebimentoService(
          new ViaRecebimentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchViaRecebimento = async (filtro?: FilterViaRecebimento | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await viarecebimentoService.getList(filtro ?? {} as FilterViaRecebimento);
        setViaRecebimento(data);
      }
      else {
        const data = await viarecebimentoService.getAll(filtro ?? {} as FilterViaRecebimento);
        setViaRecebimento(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchViaRecebimento(currFilter);
    }, [showInc]);
  
    const handleRowClick = (viarecebimento: IViaRecebimento) => {
      if (isMobile) {
        router.push(`/pages/viarecebimento/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${viarecebimento.id}`);
      } else {
        setSelectedViaRecebimento(viarecebimento);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/viarecebimento/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedViaRecebimento(ViaRecebimentoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchViaRecebimento(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const viarecebimento = e.dataItem;		
        setDeleteId(viarecebimento.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchViaRecebimento(currFilter);
            } catch {
            // falta uma mensagem de erro
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

    return (
      <>
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <ViaRecebimentoGridMobileComponent data={viarecebimento} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ViaRecebimentoGridDesktopComponent data={viarecebimento} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ViaRecebimentoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedViaRecebimento={selectedViaRecebimento}>       
        </ViaRecebimentoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ViaRecebimentoGrid;