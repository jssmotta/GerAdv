//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { RamalEmpty } from "../../../Models/Ramal";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import RamalInc from "../Inc/Ramal";
import { IRamal } from "../../Interfaces/interface.Ramal";
import { RamalService } from "../../Services/Ramal.service";
import { RamalApi } from "../../Apis/ApiRamal";
import { RamalGridMobileComponent } from "../GridsMobile/Ramal";
import { RamalGridDesktopComponent } from "../GridsDesktop/Ramal";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterRamal } from "../../Filters/Ramal";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import RamalWindow from "./RamalWindow";

const RamalGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [ramal, setRamal] = useState<IRamal[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedRamal, setSelectedRamal] = useState<IRamal>(RamalEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new RamalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterRamal | undefined | null>(null);

    const ramalService = useMemo(() => {
      return new RamalService(
          new RamalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchRamal = async (filtro?: FilterRamal | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await ramalService.getList(filtro ?? {} as FilterRamal);
        setRamal(data);
      }
      else {
        const data = await ramalService.getAll(filtro ?? {} as FilterRamal);
        setRamal(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchRamal(currFilter);
    }, [showInc]);
  
    const handleRowClick = (ramal: IRamal) => {
      if (isMobile) {
        router.push(`/pages/ramal/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${ramal.id}`);
      } else {
        setSelectedRamal(ramal);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/ramal/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedRamal(RamalEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchRamal(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const ramal = e.dataItem;		
        setDeleteId(ramal.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchRamal(currFilter);
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
           <RamalGridMobileComponent data={ramal} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <RamalGridDesktopComponent data={ramal} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <RamalWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedRamal={selectedRamal}>       
        </RamalWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default RamalGrid;