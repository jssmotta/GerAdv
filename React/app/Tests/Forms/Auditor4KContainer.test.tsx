import React from 'react';
import { render } from '@testing-library/react';
import Auditor4KIncContainer from '@/app/GerAdv_TS/Auditor4K/Components/Auditor4KIncContainer';
// Auditor4KIncContainer.test.tsx
// Mock do Auditor4KInc
jest.mock('@/app/GerAdv_TS/Auditor4K/Crud/Inc/Auditor4K', () => (props: any) => (
<div data-testid='auditor4k-inc-mock' {...props} />
));
describe('Auditor4KIncContainer', () => {
  it('deve renderizar Auditor4KInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <Auditor4KIncContainer id={id} navigator={mockNavigator} />
  );
  const auditor4kInc = getByTestId('auditor4k-inc-mock');
  expect(auditor4kInc).toBeInTheDocument();
  expect(auditor4kInc.getAttribute('id')).toBe(id.toString());

});
});