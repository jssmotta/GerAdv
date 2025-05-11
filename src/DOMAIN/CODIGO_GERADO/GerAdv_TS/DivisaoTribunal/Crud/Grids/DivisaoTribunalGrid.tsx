//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { DivisaoTribunalEmpty } from "../../../Models/DivisaoTribunal";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IDivisaoTribunal } from "../../Interfaces/interface.DivisaoTribunal";
import { DivisaoTribunalService } from "../../Services/DivisaoTribunal.service";
import { DivisaoTribunalApi } from "../../Apis/ApiDivisaoTribunal";
import { DivisaoTribunalGridMobileComponent } from "../GridsMobile/DivisaoTribunal";
import { DivisaoTribunalGridDesktopComponent } from "../GridsDesktop/DivisaoTribunal";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterDivisaoTribunal } from "../../Filters/DivisaoTribunal";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import DivisaoTribunalWindow from "./DivisaoTribunalWindow";

const DivisaoTribunalGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [divisaotribunal, setDivisaoTribunal] = useState<IDivisaoTribunal[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedDivisaoTribunal, setSelectedDivisaoTribunal] = useState<IDivisaoTribunal>(DivisaoTribunalEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new DivisaoTribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterDivisaoTribunal | undefined | null>(null);

    const divisaotribunalService = useMemo(() => {
      return new DivisaoTribunalService(
          new DivisaoTribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchDivisaoTribunal = async (filtro?: FilterDivisaoTribunal | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await divisaotribunalService.getAll(filtro ?? {} as FilterDivisaoTribunal);
        setDivisaoTribunal(data);
      }
      else {
        const data = await divisaotribunalService.getAll(filtro ?? {} as FilterDivisaoTribunal);
        setDivisaoTribunal(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchDivisaoTribunal(currFilter);
    }, [showInc]);
  
    const handleRowClick = (divisaotribunal: IDivisaoTribunal) => {
      if (isMobile) {
        router.push(`/pages/divisaotribunal/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${divisaotribunal.id}`);
      } else {
        setSelectedDivisaoTribunal(divisaotribunal);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/divisaotribunal/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedDivisaoTribunal(DivisaoTribunalEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchDivisaoTribunal(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const divisaotribunal = e.dataItem;		
        setDeleteId(divisaotribunal.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchDivisaoTribunal(currFilter);
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
           <DivisaoTribunalGridMobileComponent data={divisaotribunal} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <DivisaoTribunalGridDesktopComponent data={divisaotribunal} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <DivisaoTribunalWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedDivisaoTribunal={selectedDivisaoTribunal}>       
        </DivisaoTribunalWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default DivisaoTribunalGrid;