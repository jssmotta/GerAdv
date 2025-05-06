//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { PontoVirtualAcessosEmpty } from "../../../Models/PontoVirtualAcessos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IPontoVirtualAcessos } from "../../Interfaces/interface.PontoVirtualAcessos";
import { PontoVirtualAcessosService } from "../../Services/PontoVirtualAcessos.service";
import { PontoVirtualAcessosApi } from "../../Apis/ApiPontoVirtualAcessos";
import { PontoVirtualAcessosGridMobileComponent } from "../GridsMobile/PontoVirtualAcessos";
import { PontoVirtualAcessosGridDesktopComponent } from "../GridsDesktop/PontoVirtualAcessos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterPontoVirtualAcessos } from "../../Filters/PontoVirtualAcessos";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import PontoVirtualAcessosWindow from "./PontoVirtualAcessosWindow";

const PontoVirtualAcessosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [pontovirtualacessos, setPontoVirtualAcessos] = useState<IPontoVirtualAcessos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedPontoVirtualAcessos, setSelectedPontoVirtualAcessos] = useState<IPontoVirtualAcessos>(PontoVirtualAcessosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new PontoVirtualAcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterPontoVirtualAcessos | undefined | null>(null);

    const pontovirtualacessosService = useMemo(() => {
      return new PontoVirtualAcessosService(
          new PontoVirtualAcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchPontoVirtualAcessos = async (filtro?: FilterPontoVirtualAcessos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await pontovirtualacessosService.getAll(filtro ?? {} as FilterPontoVirtualAcessos);
        setPontoVirtualAcessos(data);
      }
      else {
        const data = await pontovirtualacessosService.getAll(filtro ?? {} as FilterPontoVirtualAcessos);
        setPontoVirtualAcessos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchPontoVirtualAcessos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (pontovirtualacessos: IPontoVirtualAcessos) => {
      if (isMobile) {
        router.push(`/pages/pontovirtualacessos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${pontovirtualacessos.id}`);
      } else {
        setSelectedPontoVirtualAcessos(pontovirtualacessos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/pontovirtualacessos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedPontoVirtualAcessos(PontoVirtualAcessosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchPontoVirtualAcessos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const pontovirtualacessos = e.dataItem;		
        setDeleteId(pontovirtualacessos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchPontoVirtualAcessos(currFilter);
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
           <PontoVirtualAcessosGridMobileComponent data={pontovirtualacessos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <PontoVirtualAcessosGridDesktopComponent data={pontovirtualacessos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <PontoVirtualAcessosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedPontoVirtualAcessos={selectedPontoVirtualAcessos}>       
        </PontoVirtualAcessosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default PontoVirtualAcessosGrid;