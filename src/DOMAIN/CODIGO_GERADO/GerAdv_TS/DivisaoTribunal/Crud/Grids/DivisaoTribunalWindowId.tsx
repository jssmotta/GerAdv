// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IDivisaoTribunal } from "../../Interfaces/interface.DivisaoTribunal";
import { DivisaoTribunalService } from "../../Services/DivisaoTribunal.service";
import { DivisaoTribunalApi } from "../../Apis/ApiDivisaoTribunal";
import DivisaoTribunalWindow from "./DivisaoTribunalWindow";

interface DivisaoTribunalWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const DivisaoTribunalWindowId: React.FC<DivisaoTribunalWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const divisaotribunalService = useMemo(() => {
        return new DivisaoTribunalService(
            new DivisaoTribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IDivisaoTribunal | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await divisaotribunalService.fetchDivisaoTribunalById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <DivisaoTribunalWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedDivisaoTribunal={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default DivisaoTribunalWindowId;