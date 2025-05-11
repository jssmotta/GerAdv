// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ISMSAlice } from "../../Interfaces/interface.SMSAlice";
import { SMSAliceService } from "../../Services/SMSAlice.service";
import { SMSAliceApi } from "../../Apis/ApiSMSAlice";
import SMSAliceWindow from "./SMSAliceWindow";

interface SMSAliceWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const SMSAliceWindowId: React.FC<SMSAliceWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const smsaliceService = useMemo(() => {
        return new SMSAliceService(
            new SMSAliceApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ISMSAlice | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await smsaliceService.fetchSMSAliceById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <SMSAliceWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedSMSAlice={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default SMSAliceWindowId;