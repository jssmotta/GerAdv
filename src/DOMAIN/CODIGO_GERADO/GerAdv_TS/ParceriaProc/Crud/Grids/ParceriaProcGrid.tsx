//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ParceriaProcEmpty } from "../../../Models/ParceriaProc";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IParceriaProc } from "../../Interfaces/interface.ParceriaProc";
import { ParceriaProcService } from "../../Services/ParceriaProc.service";
import { ParceriaProcApi } from "../../Apis/ApiParceriaProc";
import { ParceriaProcGridMobileComponent } from "../GridsMobile/ParceriaProc";
import { ParceriaProcGridDesktopComponent } from "../GridsDesktop/ParceriaProc";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterParceriaProc } from "../../Filters/ParceriaProc";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ParceriaProcWindow from "./ParceriaProcWindow";

const ParceriaProcGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [parceriaproc, setParceriaProc] = useState<IParceriaProc[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedParceriaProc, setSelectedParceriaProc] = useState<IParceriaProc>(ParceriaProcEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ParceriaProcApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterParceriaProc | undefined | null>(null);

    const parceriaprocService = useMemo(() => {
      return new ParceriaProcService(
          new ParceriaProcApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchParceriaProc = async (filtro?: FilterParceriaProc | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await parceriaprocService.getAll(filtro ?? {} as FilterParceriaProc);
        setParceriaProc(data);
      }
      else {
        const data = await parceriaprocService.getAll(filtro ?? {} as FilterParceriaProc);
        setParceriaProc(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchParceriaProc(currFilter);
    }, [showInc]);
  
    const handleRowClick = (parceriaproc: IParceriaProc) => {
      if (isMobile) {
        router.push(`/pages/parceriaproc/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${parceriaproc.id}`);
      } else {
        setSelectedParceriaProc(parceriaproc);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/parceriaproc/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedParceriaProc(ParceriaProcEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchParceriaProc(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const parceriaproc = e.dataItem;		
        setDeleteId(parceriaproc.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchParceriaProc(currFilter);
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
           <ParceriaProcGridMobileComponent data={parceriaproc} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ParceriaProcGridDesktopComponent data={parceriaproc} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ParceriaProcWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedParceriaProc={selectedParceriaProc}>       
        </ParceriaProcWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ParceriaProcGrid;