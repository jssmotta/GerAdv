// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { INECompromissos } from "../../Interfaces/interface.NECompromissos";
import { NECompromissosService } from "../../Services/NECompromissos.service";
import { NECompromissosApi } from "../../Apis/ApiNECompromissos";
import NECompromissosWindow from "./NECompromissosWindow";

interface NECompromissosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const NECompromissosWindowId: React.FC<NECompromissosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const necompromissosService = useMemo(() => {
        return new NECompromissosService(
            new NECompromissosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<INECompromissos | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await necompromissosService.fetchNECompromissosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <NECompromissosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedNECompromissos={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default NECompromissosWindowId;