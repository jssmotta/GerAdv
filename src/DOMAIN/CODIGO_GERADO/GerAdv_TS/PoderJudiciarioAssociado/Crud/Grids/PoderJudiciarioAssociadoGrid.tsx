//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { PoderJudiciarioAssociadoEmpty } from "../../../Models/PoderJudiciarioAssociado";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IPoderJudiciarioAssociado } from "../../Interfaces/interface.PoderJudiciarioAssociado";
import { PoderJudiciarioAssociadoService } from "../../Services/PoderJudiciarioAssociado.service";
import { PoderJudiciarioAssociadoApi } from "../../Apis/ApiPoderJudiciarioAssociado";
import { PoderJudiciarioAssociadoGridMobileComponent } from "../GridsMobile/PoderJudiciarioAssociado";
import { PoderJudiciarioAssociadoGridDesktopComponent } from "../GridsDesktop/PoderJudiciarioAssociado";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterPoderJudiciarioAssociado } from "../../Filters/PoderJudiciarioAssociado";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import PoderJudiciarioAssociadoWindow from "./PoderJudiciarioAssociadoWindow";

const PoderJudiciarioAssociadoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [poderjudiciarioassociado, setPoderJudiciarioAssociado] = useState<IPoderJudiciarioAssociado[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedPoderJudiciarioAssociado, setSelectedPoderJudiciarioAssociado] = useState<IPoderJudiciarioAssociado>(PoderJudiciarioAssociadoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new PoderJudiciarioAssociadoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterPoderJudiciarioAssociado | undefined | null>(null);

    const poderjudiciarioassociadoService = useMemo(() => {
      return new PoderJudiciarioAssociadoService(
          new PoderJudiciarioAssociadoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchPoderJudiciarioAssociado = async (filtro?: FilterPoderJudiciarioAssociado | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await poderjudiciarioassociadoService.getAll(filtro ?? {} as FilterPoderJudiciarioAssociado);
        setPoderJudiciarioAssociado(data);
      }
      else {
        const data = await poderjudiciarioassociadoService.getAll(filtro ?? {} as FilterPoderJudiciarioAssociado);
        setPoderJudiciarioAssociado(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchPoderJudiciarioAssociado(currFilter);
    }, [showInc]);
  
    const handleRowClick = (poderjudiciarioassociado: IPoderJudiciarioAssociado) => {
      if (isMobile) {
        router.push(`/pages/poderjudiciarioassociado/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${poderjudiciarioassociado.id}`);
      } else {
        setSelectedPoderJudiciarioAssociado(poderjudiciarioassociado);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/poderjudiciarioassociado/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedPoderJudiciarioAssociado(PoderJudiciarioAssociadoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchPoderJudiciarioAssociado(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const poderjudiciarioassociado = e.dataItem;		
        setDeleteId(poderjudiciarioassociado.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchPoderJudiciarioAssociado(currFilter);
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
            
        {isMobile ?
           <PoderJudiciarioAssociadoGridMobileComponent data={poderjudiciarioassociado} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <PoderJudiciarioAssociadoGridDesktopComponent data={poderjudiciarioassociado} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <PoderJudiciarioAssociadoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedPoderJudiciarioAssociado={selectedPoderJudiciarioAssociado}>       
        </PoderJudiciarioAssociadoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default PoderJudiciarioAssociadoGrid;