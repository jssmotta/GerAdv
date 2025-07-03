import React from 'react';
import { render } from '@testing-library/react';
import DocumentosIncContainer from '@/app/GerAdv_TS/Documentos/Components/DocumentosIncContainer';
// DocumentosIncContainer.test.tsx
// Mock do DocumentosInc
jest.mock('@/app/GerAdv_TS/Documentos/Crud/Inc/Documentos', () => (props: any) => (
<div data-testid='documentos-inc-mock' {...props} />
));
describe('DocumentosIncContainer', () => {
  it('deve renderizar DocumentosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <DocumentosIncContainer id={id} navigator={mockNavigator} />
  );
  const documentosInc = getByTestId('documentos-inc-mock');
  expect(documentosInc).toBeInTheDocument();
  expect(documentosInc.getAttribute('id')).toBe(id.toString());

});
});