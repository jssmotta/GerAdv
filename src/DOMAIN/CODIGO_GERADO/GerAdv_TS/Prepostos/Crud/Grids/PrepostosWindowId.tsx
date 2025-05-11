// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IPrepostos } from "../../Interfaces/interface.Prepostos";
import { PrepostosService } from "../../Services/Prepostos.service";
import { PrepostosApi } from "../../Apis/ApiPrepostos";
import PrepostosWindow from "./PrepostosWindow";

interface PrepostosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const PrepostosWindowId: React.FC<PrepostosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const prepostosService = useMemo(() => {
        return new PrepostosService(
            new PrepostosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IPrepostos | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await prepostosService.fetchPrepostosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <PrepostosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedPrepostos={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default PrepostosWindowId;