'use client';

import { useIsMobile } from '@/app/context/MobileContext';
import { DatePicker } from '@progress/kendo-react-dateinputs';
import * as React from 'react';

interface ClientOnlyDatePickerProps {
  value: Date | null;
  onChange: (event: any) => void;
  width: number;
  height: number;
}

const ClientOnlyDatePicker: React.FC<ClientOnlyDatePickerProps> = (props) => {
  // Use useState and useEffect to ensure client-only rendering
  const [isMounted, setIsMounted] = React.useState(false);
  const isMobile = useIsMobile();

  React.useEffect(() => {
    setIsMounted(true);
  }, []);

  // Only render the DatePicker on the client
  if (!isMounted) {
    return null;
  }

  return (
    <>
      <style>
        {`
        .k-top-header {
          height: ${props.height}px;       
        }        
      `}
      </style>
      <DatePicker
        value={props.value}
        onChange={props.onChange}
        width={isMobile ? 200 : props.width}
        className="k-top-header k-input-date-agenda"
      />
    </>
  );
};

export default ClientOnlyDatePicker;
